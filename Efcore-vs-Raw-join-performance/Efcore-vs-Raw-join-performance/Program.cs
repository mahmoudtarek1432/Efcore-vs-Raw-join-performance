// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using Efcore_vs_Raw_join_performance;
using Efcore_vs_Raw_join_performance.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");

BenchmarkRunner.Run<Approaches>();

//new Approaches().BrokeDownEF();
Console.WriteLine("match data");