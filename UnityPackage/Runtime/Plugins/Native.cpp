#pragma once
#include "pch-cpp.hpp"

#include <limits>
#include <stdint.h>

#include <iostream>
#include <fstream>
// #include <string>
// #include <codecvt>

#ifndef _MSC_VER
#include <alloca.h>
#else
#include <malloc.h>
#endif

#if defined(__cplusplus)
#define EXC extern "C"
#else
#define EXC
#endif

#if defined(WIN32) || defined(_WIN32) || defined(__WIN32__) || defined(__NT__)
#define CALL __stdcall
#if defined(__IDP__)
#define EXPORT EXC
#else
#if defined(__X64__) || defined(_WIN64) || defined(__NOEXPORT__)
#define EXPORT EXC
#else
#define EXPORT EXC __declspec(dllexport)
#endif
#endif
#elif defined(__APPLE__) && defined(__MACH__)
#include <TargetConditionals.h>
#define CALL
#define EXPORT EXC __attribute__((visibility("default")))
#define LOCAL __attribute__((visibility("hidden")))
#elif defined(__linux__) || defined(__unix__) || defined(__unix)
#define CALL
#if __GNUC__ >= 4
#define EXPORT EXC __attribute__((visibility("default")))
#define LOCAL __attribute__((visibility("hidden")))
#else
#define EXPORT EXC
#define LOCAL
#endif
#endif

typedef struct Il2CppObject Il2CppObject;
typedef struct Il2CppReflectionMethod Il2CppReflectionMethod;
typedef struct Il2CppReflectionType Il2CppReflectionType;

using namespace std;

EXPORT void CALL __IL2CPP_LOG(const char* log)
{
    ofstream logFile;
    logFile.open("log.txt", std::ios_base::app);

    if (logFile.is_open())
    {
        logFile << "LOG: " << log << "\n";
    }
}

EXPORT void CALL __IL2CPP_UNHOOK(intptr_t* ptr)
{
    if (*ptr == 0)
        return;

    // Original Method
    Il2CppReflectionMethod* originalMethod = reinterpret_cast<Il2CppReflectionMethod*>(*(ptr + 1));
    const MethodInfo* originalMethodInfo = originalMethod->method;

    *(Il2CppMethodPointer*)&originalMethodInfo->methodPointer = (Il2CppMethodPointer)*ptr;

    *ptr = 0;
}

EXPORT void CALL __IL2CPP_HOOK(intptr_t* ptr)
{
    if (*ptr != 0)
        return;

    // Original Method
    Il2CppReflectionMethod* originalMethod = reinterpret_cast<Il2CppReflectionMethod*>(*(ptr + 1));
    const MethodInfo* originalMethodInfo = originalMethod->method;
    // const Il2CppImage *originalImage = originalMethodInfo->klass->image;
    // const Il2CppCodeGenModule *originalCodeGenModule = originalImage->codeGenModule;
    // const Il2CppMethodPointer *originalModulePointers = originalCodeGenModule->methodPointers;

    // Save a value of the original method pointer
    *ptr = (intptr_t)originalMethodInfo->methodPointer;

    // Inject Method
    Il2CppReflectionMethod* injectMethod = reinterpret_cast<Il2CppReflectionMethod*>(*(ptr + 2));
    const MethodInfo* injectMethodInfo = injectMethod->method;
    // const Il2CppImage *injectImage = injectMethodInfo->klass->image;
    // const Il2CppCodeGenModule *injectCodeGenModule = injectImage->codeGenModule;
    // const Il2CppMethodPointer *injectModulePointers = injectCodeGenModule->methodPointers;

    // Injection
    *(Il2CppMethodPointer*)&originalMethodInfo->methodPointer = injectMethodInfo->methodPointer;
}