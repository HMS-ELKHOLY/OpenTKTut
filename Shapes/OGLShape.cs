﻿/*H**********************************************************************
* FILENAME :        OGLShape.cs             DESIGN REF: OGLTUT04
*
* DESCRIPTION :
*       OGLShape object base functions of all shapes.
*
* PUBLIC FUNCTIONS :
*       void     Draw()
*       void     ShapeDrawing( FileHandle )
*      
*
* NOTES :
*       These functions are a part of the Computer Graphics course materias suite;
*      
*
*       Copyright Amr M. Gody. 2019, 2019.  All rights reserved.
*
* AUTHOR :    Amr M. Gody        START DATE :    24 OCT 2019
*
* CHANGES :
*
* REF NO  VERSION DATE    WHO     DETAIL
* 1       1       24OCT19 AG      first working version
*
*******************************************************************************H*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace OpenTKTut.Shapes
{
    class OGLShape
    {
        public bool EnableAutoRotate { get; set; }
        public bool EnableAutoRotate_at_other_place { get; set; }

        public Vector3 Center { get; set; }
        public Vector3 Center_rotate { get; set; }

        public MeshElement[] MeshPolygons { get => meshPolygons; set => meshPolygons = value; }

        protected float _rotateAngle;
        protected float _rotateAngle_other_place;

        private MeshElement[] meshPolygons;

        public virtual void Draw()
        {
            GL.PushMatrix();
             GL.Color3(1.0f, 0.0f, 0.0f    );
            if (EnableAutoRotate_at_other_place)
            {
                GL.Translate(Center_rotate.X, Center_rotate.Y, -Center_rotate.Z);
                GL.Rotate(90, Vector3.UnitX);
                GL.Rotate(_rotateAngle_other_place, Vector3.UnitY);
                GL.Translate(-Center_rotate.X, -Center_rotate.Y, Center_rotate.Z);
                _rotateAngle_other_place = _rotateAngle_other_place < 360 ? _rotateAngle_other_place + 1 : _rotateAngle_other_place - 360;
            }
            GL.Translate(Center.X, Center.Y, -Center.Z);

            if (EnableAutoRotate)
                {
                GL.Color3(1.0f, 0.0f, 0.0f);

                GL.Rotate(_rotateAngle, Vector3.UnitX);
                    GL.Rotate(_rotateAngle, Vector3.UnitZ);
                    _rotateAngle = _rotateAngle < 360 ? _rotateAngle + 1 : _rotateAngle - 360;
                }
            
            ShapeDrawing();
            GL.PopMatrix();
        }

        protected virtual void ShapeDrawing()
        {
            //Add any common drawing for all shapes in this part
        }


    }
}