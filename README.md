# README

## TL:DR

 Unity 2017.3 breaks simple surface shader lighting that worked in 2017.2, under the following conditions:

 - No normals in the mesh
 - `o.Normal` generated as a constant in the surface shader
 - Running on OpenGL 3.3/4.1 (at least) - Metal and DirectX are not affected

## Details

After upgrading to Unity 2017.3 from 2017.2, we noticed that a few of our shaders were
rendering black (unlit, shape & texture access seemed to still be correct) on an old
MacBook Pro 2010 running a 330M. 2 Windows machines and a newer MacBook were not affected.

On closer examination I discovered I could re-create the issue on a 2013 MacBook (750M) by forcing
the use of OpenGL instead of Metal. On the 330M the OpenGL version is 3.3, but the problem also
occurred on GL 4.1 on the 750M.

I eventually discovered that the problem was caused by manually emitting normals in the surface
shader, when the mesh has no normals (and the vertex shader makes no mention of them). I do this
because this is 2D geometry and I know the final normal is just -Z.

Moving the geneation of the normal to the vertex shader, and removing it from the surface shader, 
resolved the issue. For some reason generating it in the surface shader *as well* doesn't work
either. 

I have reproduced this in this project. There are 2 manually generated quads with no normals, 
both using simple surface shaders and a directional light. The left one generates the normal 
in the vertex shader and works, the right one generates it in the pixel shader and renders black.
The right hand one works fine if you use Unity 2017.2 instead.

Submitting this as a bug, but uploaded to GitHub for info.