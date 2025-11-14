This is the unique monster tombstone. It imported with a skeleton, but with only one bone ("EX_body"), making it meaningless, so I didn't include it at all.

Model notes:
* Most if not all skin-textured/skin-tight models have a separate "outline" mesh. I have not included any outlines if they have the exact same shape as the actual mesh.
* While importing the models into Blender, I selected an option to automatically weld seams that have the same vertex normals, which should (should) leave no question as to what edges should be smooth. Other than this, I have generally not welded or split any edges from the model's raw state.
* Some models are packaged as multiple separate mesh objects. Sometimes this is to make it easier to set materials correctly, while other times it's to make it obvious what exactly can be turned visible/invisible (e.g. the crystal in Rex's chest). You may need to merge meshes together and weld the seams if there isn't supposed to be a sharp edge there, but you will never need to split a mesh to get something as it appears in-game.
* Attachments (e.g. weapons) may have to be rotated to match the bone they're attached to. These rotations will always be some multiple of 90 degrees around the bone's local axes.
** Attachments need to be on the root of the bone, not the tip. (Blender parents objects to bone tips, so you have to reposition them to the root. Not sure if other programs do similar.)
* Most models import with fully black vertex colours, which I take to mean "none" and so delete them. The few that do not seem fully black, I leave them be.

Material/texture notes:
* Many textures required minor renaming in order to not conflict with each other (for example, a lot of things have a "temp0000" texture). I have attempted to be minimal and unambiguous with these renamings.
* In general, materials do not import/export well. You are likely to need some trial and error to find out what fits where.
* Typical texture types, in the order they should generally be applied, include:
** Colour textures are the "main" texture. Generally obvious.
** Ambient occlusion textures should be multiplied with the colour texture. They tend to be white and end in "_AO".
** Normal textures provide bump mapping. They tend to be bluish and end in "_NRM".
*** For some reason, a lot of XC2 normal maps set the blue to 0 instead of 1. Since that's nonstandard, I changed them to the standard, and provided the originals if you care.
*** Blender is terrible with leaving seams at the edge of mirrored normal maps (and other programs probably are too.) If it's really bad, I will edit the normal texture to reduce seams while still including the original, but I'll leave most of them alone.
** Glow textures provide shadeless bits/emission mapping. They end in "_GLO" or similar. Depending on the model, it might include the glow colour in its own right, or it might simply apply to the underlying colour.
** Specularity textures control shininess, both in the "size of specularity" and "degree of specularity" senses. I personally (in Blender) set the base material to have 0.0 intensity with 10 hardness (so it's off and rough by default), so that a textured influence of 1.0 for each results in having 1.0 intensity and 140 hardness (Blender's max hardness is 511, and an influence of +1.0 equals +130 hardness). There are two images for this, a _SHY (roughness/glossiness) and a _MTL (intensity).
*** I've seen "_SPM" textures as well. My best guess is "specularity colour".
** Alpha textures control transparency; if not present, the material is fully solid. They end with "_ALP" or "_A".
** Finally, there may be an image called "temp0000" or similar. It's unclear why, but often it's used channellized instead of one (or many) of the options above. Usually, the red channel is specularity roughness/glossiness, the green channel is AO, and the blue channel is specularity intensity, but in theory they could be anything that isn't colour or normal. Sometimes one such image even applies its channels to entirely different meshes. (Hopefully I've remembered to make a specific note on this above, for these cases.)
*** You need to make sure that your program isn't trying to be tricky with these. Blender gave me so much trouble with turning max blue into dark grey (rather than max white, because fancy colour math) that I also split each channel into individual greyscale component images.
* Blender may produce (possibly hard-to-see) artifacts at pixels where opaque materials meet transparent ones if anti-aliasing is on. To fix this, enable Render > Anti-Aliasing > Full Sample.
* There might also be texture blending artifacts caused by alpha textures being lower-resolution than colour textures, or pixel interpolation. Just mess with settings I guess.
* Some things may need texture tiling to be on mirror rather than repeat. I have attempted to make a convention where UVs entirely within image bounds are not mirrored, while those with bits outside image bounds are; unfortunately this can't be perfect, as sometimes something does stick out slightly when not mirrored.
* Some meshes require multiple UV maps (e.g. scrolling glows). Since apparently (according to tMR staff) not everything is capable of importing these correctly, I've been asked to provide extra models with split UVs, under a file called "thing_splitUVs.dae". If the "default" file doesn't import correctly, this contains a separate mesh object for every necessary UV map, and try to put them back together yourself. I should have included specific instructions above if this is the case.

Armature notes:
* Almost all bones are included, even those that don't necessarily apply to this model, or are only reference points rather than animation controls (e.g. special effect markers, weapon attach points).
* Many manual edits had to be done to get things to function (e.g. most endpoint bones weren't facing the right way). Don't expect ripped animations to work.
* Some bones were minorly renamed to put the _L/_R at the end instead of in the middle.

[EOF]