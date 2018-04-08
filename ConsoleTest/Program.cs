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
            DMesh3Builder builder = new DMesh3Builder();
            StandardMeshReader reader = new StandardMeshReader();
            reader.MeshBuilder = builder;
            var readResult = reader.Read(@"D:\Eksamen 4th semester\Pointclouds\triangle1.obj", new ReadOptions());
            var readResult2 = reader.Read(@"D:\Eksamen 4th semester\Pointclouds\triangle2.obj", new ReadOptions());



            DMeshAABBTree3 tree = new DMeshAABBTree3(builder.Meshes[1], autoBuild: true);
            
            MeshICP calc = new MeshICP(builder.Meshes[0], tree);
            calc.Solve();
            calc.Solve(bUpdate: true);
            Console.WriteLine(calc.Rotation);
            Console.WriteLine(calc.Translation);
            Console.WriteLine();
            Console.ReadKey();
        }
    }



}
