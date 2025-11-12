
using GesEtudiant.Repository;
using GesEtudiant.Repository.Impl;
using GesEtudiant.Service;
using GesEtudiant.Service.Impl;
using GesEtudiant.Views;
using Microsoft.Extensions.DependencyInjection;

var ioc = new ServiceCollection();
ioc.AddSingleton<IClasseRepository, ClasseRepository>();
ioc.AddSingleton<IEtudiantRepository, EtudiantRepository>();
ioc.AddSingleton<IClasseService, ClasseService>();
ioc.AddSingleton<IEtudiantService, EtudiantService>();
ioc.AddTransient<ConsoleViews>();
var serviceProvider = ioc.BuildServiceProvider();
var consoleViews = serviceProvider.GetRequiredService<ConsoleViews>();
consoleViews.Run();