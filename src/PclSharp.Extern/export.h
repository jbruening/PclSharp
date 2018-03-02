#pragma once

#ifndef EXPORT
#  define EXPORT(rettype) __declspec( dllexport ) rettype __cdecl
#endif
