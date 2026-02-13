cmake_minimum_required(VERSION 3.18)

project(psychic-octo-guide LANGUAGES C CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_POSITION_INDEPENDENT_CODE ON)

# ✅ REAL source file (confirmed by you)
set(MOXXIE_SOURCES
    "${CMAKE_CURRENT_SOURCE_DIR}/app/src/main/cpp/libmoxxie.cpp"
)

# Safety check (helps future debugging)
if(NOT EXISTS "${MOXXIE_SOURCES}")
    message(FATAL_ERROR "Missing source file: ${MOXXIE_SOURCES}")
endif()

add_library(moxxie SHARED ${MOXXIE_SOURCES})

# Android log lib (safe)
find_library(log-lib log)
if(log-lib)
    target_link_libraries(moxxie PUBLIC ${log-lib})
endif()

# Put .so in build root for easier finding
set_target_properties(moxxie PROPERTIES
    LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}
)
