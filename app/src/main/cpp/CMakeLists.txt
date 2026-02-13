cmake_minimum_required(VERSION 3.18)
project(psychic-octo-guide LANGUAGES C CXX)

set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_POSITION_INDEPENDENT_CODE ON)

# Subdirectory CMakeLists: current dir is app/src/main/cpp, so refer only to libmoxxie.cpp
set(MOXXIE_SOURCES
    "${CMAKE_CURRENT_SOURCE_DIR}/libmoxxie.cpp"
    # or simply: "libmoxxie.cpp"
)

if(NOT EXISTS "${MOXXIE_SOURCES}")
    message(FATAL_ERROR "Missing source file: ${MOXXIE_SOURCES}\nCheck that libmoxxie.cpp is in this directory.")
endif()

add_library(moxxie SHARED ${MOXXIE_SOURCES})

find_library(log-lib log)
if(log-lib)
    target_link_libraries(moxxie PUBLIC ${log-lib})
endif()

set_target_properties(moxxie PROPERTIES
    LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR}
)
