using pointmatcher.net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Numerics;
using g3;


namespace ConsoleTest
{
    public class Program
    {

        private static Random r = new Random();

        static void Main(string[] args)
        {
            var p = new Program();
            p.Run();
        }

        public void Run()
        {

            // Target = Element you transform around.
            // Source = Element you want to transform.
            DMesh3Builder builder = new DMesh3Builder();
            StandardMeshReader reader = new StandardMeshReader();
            reader.MeshBuilder = builder;
            var Target = reader.Read(@"D:\Eksamen 4th semester\Pointclouds\triangle2.obj", new ReadOptions());
            var Source = reader.Read(@"D:\Eksamen 4th semester\Pointclouds\triangle1.obj", new ReadOptions());



            DMeshAABBTree3 tree = new DMeshAABBTree3(builder.Meshes[0], autoBuild: true);
            
            MeshICP calc = new MeshICP(builder.Meshes[1], tree);
            calc.Solve();
            calc.Solve(bUpdate: true);
            Console.WriteLine(calc.Rotation);
            Console.WriteLine(calc.Translation);
            Console.WriteLine();
            DMesh3 source = builder.Meshes[1];
            DMesh3 target = builder.Meshes[0];
            foreach (var item in source.Vertices())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------");

            Func<Vector3d, Vector3d> TransformF = (v1) => {
                return v1 += calc.Translation;
            };
            MeshTransforms.PerVertexTransform(source, TransformF);

            foreach (var item in source.Vertices())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------");

            foreach (var  item in target.Vertices())
            {
                Console.WriteLine(item);
            }
            
            Console.ReadKey();
        }
    }



}
