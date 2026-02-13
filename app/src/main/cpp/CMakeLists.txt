cmake_minimum_required(VERSION 3.18)

project(moxxie LANGUAGES C CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# 🔴 IMPORTANT:
# Replace these with the REAL source files in your repo
set(MOXXIE_SOURCES
    src/moxxie.cpp
)

add_library(moxxie SHARED ${MOXXIE_SOURCES})

# Android system libs (safe even if unused)
target_link_libraries(moxxie
    log
    android
)
