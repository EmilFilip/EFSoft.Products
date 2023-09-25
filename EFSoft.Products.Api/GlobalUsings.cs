global using System.Diagnostics.CodeAnalysis;

global using EFSoft.Products.Api.Configuration;
global using EFSoft.Products.Api.Endpoints;
global using EFSoft.Products.Application.Commands.CreateProduct;
global using EFSoft.Products.Application.Commands.DeleteProduct;
global using EFSoft.Products.Application.Commands.UpdateProduct;
global using EFSoft.Products.Application.Queries.GetProduct;
global using EFSoft.Products.Application.Queries.GetProducts;
global using EFSoft.Products.Application.RepositoryContracts;
global using EFSoft.Products.Domain.Models;
global using EFSoft.Products.Infrastructure.DBContexts;
global using EFSoft.Products.Infrastructure.Repositories;
global using EFSoft.Shared.Cqrs.Configuration;

global using MediatR;

global using Microsoft.AspNetCore.Http.HttpResults;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
