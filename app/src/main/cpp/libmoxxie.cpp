#include <jni.h>
#include <android/log.h>
#include <cstring>

#define LOG_TAG "libmoxxie"
#define LOGI(...) __android_log_print(ANDROID_LOG_INFO, LOG_TAG, __VA_ARGS__)
#define LOGE(...) __android_log_print(ANDROID_LOG_ERROR, LOG_TAG, __VA_ARGS__)

struct ModInfo {
    const char* id;
    const char* name;
    const char* version;
    const char* author;
    const char* description;
};

extern "C" void setup(ModInfo& info) {
    info.id = "libmoxxie";
    info.name = "libmoxxie";
    info.version = "1.0.0";
    info.author = "moxxie";
    info.description = "HoldableTemplate Scotland2 test build";
    LOGI("setup() called");
}

extern "C" void load() {
    LOGI("libmoxxie load() called — mod initialized");
}

extern "C" jint JNI_OnLoad(JavaVM* vm, void* reserved) {
    LOGI("JNI_OnLoad fired");
    return JNI_VERSION_1_6;
}
