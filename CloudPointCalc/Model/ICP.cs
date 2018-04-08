using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using g3;

namespace CloudPointCalc.Model
{
    public class ICPcalc
    {


        public void Calculate(DMesh3Builder mesh)
        {
            var icp = ICP(mesh);

            DMesh3 source = mesh.Meshes[1];

            //Func<Vector3d, Vector3d> TransformVector = (x, f) =>
            //{
            //    return (Vector3d)
            //};
            Func<Vector3d, Vector3d> TransformF = (v1, v2) => {
                return 
            };
            Vector3d res = MeshTransforms.PerVertexTransform(source, );
           
        }



        public MeshICP ICP(DMesh3Builder mesh)
        {
            DMeshAABBTree3 tree = new DMeshAABBTree3(mesh.Meshes[1], autoBuild: true);

            MeshICP calc = new MeshICP(mesh.Meshes[0], tree);
            calc.Solve();
            calc.Solve(bUpdate: true);

            return calc;

        }
    }
}
