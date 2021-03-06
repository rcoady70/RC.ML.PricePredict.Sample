﻿// This file was auto-generated by ML.NET Model Builder. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace RC.ML.PricePredict
{
    public partial class MLModel1
    {
        public static ITransformer RetrainPipeline(MLContext context, IDataView trainData)
        {
            var pipeline = BuildPipeline(context);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.Categorical.OneHotEncoding(new []{new InputOutputColumnPair(@"CPU", @"CPU"),new InputOutputColumnPair(@"GPU", @"GPU"),new InputOutputColumnPair(@"RAMType", @"RAMType"),new InputOutputColumnPair(@"SSD", @"SSD")})      
                                    .Append(mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"GHz", @"GHz"),new InputOutputColumnPair(@"RAM", @"RAM"),new InputOutputColumnPair(@"Screen", @"Screen"),new InputOutputColumnPair(@"Storage", @"Storage"),new InputOutputColumnPair(@"Weight", @"Weight")}))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"CPU",@"GPU",@"RAMType",@"SSD",@"GHz",@"RAM",@"Screen",@"Storage",@"Weight"}))      
                                    .Append(mlContext.Regression.Trainers.FastForest(new FastForestRegressionTrainer.Options(){NumberOfTrees=5,FeatureFraction=0.417739813922209F,LabelColumnName=@"Price",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
}
