using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using EntertainmentPortal.DataAccess.Context;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EntertainmentPortal.DataAccess.Migrations.Sudoku
{
    public class SudokuConfiguration : DbMigrationsConfiguration<SudokuContext>
    {
        public SudokuConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Sudoku";
        }

        protected override void Seed(SudokuContext context)
        {
            var cells = new List<CellDbModel>()
            {
                new CellDbModel {BlockNumber = 0, IsConst = false, Value = 4, XCoordinate = 0, YCoordinate = 0},
                new CellDbModel {BlockNumber = 0, IsConst = false, Value = 6, XCoordinate = 0, YCoordinate = 1},
                new CellDbModel {BlockNumber = 0, IsConst = false, Value = 3, XCoordinate = 0, YCoordinate = 2},
                new CellDbModel {BlockNumber = 1, IsConst = true, Value = 1, XCoordinate = 0, YCoordinate = 3},
                new CellDbModel {BlockNumber = 1, IsConst = true, Value = 8, XCoordinate = 0, YCoordinate = 4},
                new CellDbModel {BlockNumber = 1, IsConst = true, Value = 2, XCoordinate = 0, YCoordinate = 5},
                new CellDbModel {BlockNumber = 2, IsConst = true, Value = 9, XCoordinate = 0, YCoordinate = 6},
                new CellDbModel {BlockNumber = 2, IsConst = true, Value = 7, XCoordinate = 0, YCoordinate = 7},
                new CellDbModel {BlockNumber = 2, IsConst = true, Value = 5, XCoordinate = 0, YCoordinate = 8},
                new CellDbModel {BlockNumber = 0, IsConst = true, Value = 5, XCoordinate = 1, YCoordinate = 0},
                new CellDbModel {BlockNumber = 0, IsConst = true, Value = 8, XCoordinate = 1, YCoordinate = 1},
                new CellDbModel {BlockNumber = 0, IsConst = true, Value = 7, XCoordinate = 1, YCoordinate = 2},
                new CellDbModel {BlockNumber = 1, IsConst = true, Value = 4, XCoordinate = 1, YCoordinate = 3},
                new CellDbModel {BlockNumber = 1, IsConst = true, Value = 6, XCoordinate = 1, YCoordinate = 4},
                new CellDbModel {BlockNumber = 1, IsConst = true, Value = 9, XCoordinate = 1, YCoordinate = 5},
                new CellDbModel {BlockNumber = 2, IsConst = true, Value = 1, XCoordinate = 1, YCoordinate = 6},
                new CellDbModel {BlockNumber = 2, IsConst = true, Value = 2, XCoordinate = 1, YCoordinate = 7},
                new CellDbModel {BlockNumber = 2, IsConst = true, Value = 3, XCoordinate = 1, YCoordinate = 8},
                new CellDbModel {BlockNumber = 0, IsConst = true, Value = 9, XCoordinate = 2, YCoordinate = 0},
                new CellDbModel {BlockNumber = 0, IsConst = true, Value = 2, XCoordinate = 2, YCoordinate = 1},
                new CellDbModel {BlockNumber = 0, IsConst = true, Value = 1, XCoordinate = 2, YCoordinate = 2},
                new CellDbModel {BlockNumber = 1, IsConst = true, Value = 3, XCoordinate = 2, YCoordinate = 3},
                new CellDbModel {BlockNumber = 1, IsConst = true, Value = 5, XCoordinate = 2, YCoordinate = 4},
                new CellDbModel {BlockNumber = 1, IsConst = true, Value = 7, XCoordinate = 2, YCoordinate = 5},
                new CellDbModel {BlockNumber = 2, IsConst = true, Value = 8, XCoordinate = 2, YCoordinate = 6},
                new CellDbModel {BlockNumber = 2, IsConst = true, Value = 6, XCoordinate = 2, YCoordinate = 7},
                new CellDbModel {BlockNumber = 2, IsConst = true, Value = 4, XCoordinate = 2, YCoordinate = 8},
                new CellDbModel {BlockNumber = 3, IsConst = true, Value = 2, XCoordinate = 3, YCoordinate = 0},
                new CellDbModel {BlockNumber = 3, IsConst = true, Value = 4, XCoordinate = 3, YCoordinate = 1},
                new CellDbModel {BlockNumber = 3, IsConst = true, Value = 8, XCoordinate = 3, YCoordinate = 2},
                new CellDbModel {BlockNumber = 4, IsConst = true, Value = 6, XCoordinate = 3, YCoordinate = 3},
                new CellDbModel {BlockNumber = 4, IsConst = true, Value = 7, XCoordinate = 3, YCoordinate = 4},
                new CellDbModel {BlockNumber = 4, IsConst = true, Value = 1, XCoordinate = 3, YCoordinate = 5},
                new CellDbModel {BlockNumber = 5, IsConst = true, Value = 3, XCoordinate = 3, YCoordinate = 6},
                new CellDbModel {BlockNumber = 5, IsConst = true, Value = 5, XCoordinate = 3, YCoordinate = 7},
                new CellDbModel {BlockNumber = 5, IsConst = true, Value = 9, XCoordinate = 3, YCoordinate = 8},
                new CellDbModel {BlockNumber = 3, IsConst = true, Value = 7, XCoordinate = 4, YCoordinate = 0},
                new CellDbModel {BlockNumber = 3, IsConst = true, Value = 5, XCoordinate = 4, YCoordinate = 1},
                new CellDbModel {BlockNumber = 3, IsConst = true, Value = 9, XCoordinate = 4, YCoordinate = 2},
                new CellDbModel {BlockNumber = 4, IsConst = true, Value = 2, XCoordinate = 4, YCoordinate = 3},
                new CellDbModel {BlockNumber = 4, IsConst = true, Value = 4, XCoordinate = 4, YCoordinate = 4},
                new CellDbModel {BlockNumber = 4, IsConst = true, Value = 3, XCoordinate = 4, YCoordinate = 5},
                new CellDbModel {BlockNumber = 5, IsConst = true, Value = 6, XCoordinate = 4, YCoordinate = 6},
                new CellDbModel {BlockNumber = 5, IsConst = true, Value = 1, XCoordinate = 4, YCoordinate = 7},
                new CellDbModel {BlockNumber = 5, IsConst = true, Value = 8, XCoordinate = 4, YCoordinate = 8},
                new CellDbModel {BlockNumber = 3, IsConst = true, Value = 1, XCoordinate = 5, YCoordinate = 0},
                new CellDbModel {BlockNumber = 3, IsConst = true, Value = 3, XCoordinate = 5, YCoordinate = 1},
                new CellDbModel {BlockNumber = 3, IsConst = true, Value = 6, XCoordinate = 5, YCoordinate = 2},
                new CellDbModel {BlockNumber = 4, IsConst = true, Value = 5, XCoordinate = 5, YCoordinate = 3},
                new CellDbModel {BlockNumber = 4, IsConst = true, Value = 9, XCoordinate = 5, YCoordinate = 4},
                new CellDbModel {BlockNumber = 4, IsConst = true, Value = 8, XCoordinate = 5, YCoordinate = 5},
                new CellDbModel {BlockNumber = 5, IsConst = true, Value = 7, XCoordinate = 5, YCoordinate = 6},
                new CellDbModel {BlockNumber = 5, IsConst = true, Value = 4, XCoordinate = 5, YCoordinate = 7},
                new CellDbModel {BlockNumber = 5, IsConst = true, Value = 2, XCoordinate = 5, YCoordinate = 8},
                new CellDbModel {BlockNumber = 6, IsConst = true, Value = 3, XCoordinate = 6, YCoordinate = 0},
                new CellDbModel {BlockNumber = 6, IsConst = true, Value = 7, XCoordinate = 6, YCoordinate = 1},
                new CellDbModel {BlockNumber = 6, IsConst = true, Value = 5, XCoordinate = 6, YCoordinate = 2},
                new CellDbModel {BlockNumber = 7, IsConst = true, Value = 9, XCoordinate = 6, YCoordinate = 3},
                new CellDbModel {BlockNumber = 7, IsConst = true, Value = 2, XCoordinate = 6, YCoordinate = 4},
                new CellDbModel {BlockNumber = 7, IsConst = true, Value = 6, XCoordinate = 6, YCoordinate = 5},
                new CellDbModel {BlockNumber = 8, IsConst = true, Value = 4, XCoordinate = 6, YCoordinate = 6},
                new CellDbModel {BlockNumber = 8, IsConst = true, Value = 8, XCoordinate = 6, YCoordinate = 7},
                new CellDbModel {BlockNumber = 8, IsConst = true, Value = 1, XCoordinate = 6, YCoordinate = 8},
                new CellDbModel {BlockNumber = 6, IsConst = true, Value = 8, XCoordinate = 7, YCoordinate = 0},
                new CellDbModel {BlockNumber = 6, IsConst = true, Value = 1, XCoordinate = 7, YCoordinate = 1},
                new CellDbModel {BlockNumber = 6, IsConst = true, Value = 4, XCoordinate = 7, YCoordinate = 2},
                new CellDbModel {BlockNumber = 7, IsConst = true, Value = 7, XCoordinate = 7, YCoordinate = 3},
                new CellDbModel {BlockNumber = 7, IsConst = true, Value = 3, XCoordinate = 7, YCoordinate = 4},
                new CellDbModel {BlockNumber = 7, IsConst = true, Value = 5, XCoordinate = 7, YCoordinate = 5},
                new CellDbModel {BlockNumber = 8, IsConst = true, Value = 2, XCoordinate = 7, YCoordinate = 6},
                new CellDbModel {BlockNumber = 8, IsConst = true, Value = 9, XCoordinate = 7, YCoordinate = 7},
                new CellDbModel {BlockNumber = 8, IsConst = true, Value = 6, XCoordinate = 7, YCoordinate = 8},
                new CellDbModel {BlockNumber = 6, IsConst = true, Value = 6, XCoordinate = 8, YCoordinate = 0},
                new CellDbModel {BlockNumber = 6, IsConst = true, Value = 9, XCoordinate = 8, YCoordinate = 1},
                new CellDbModel {BlockNumber = 6, IsConst = true, Value = 2, XCoordinate = 8, YCoordinate = 2},
                new CellDbModel {BlockNumber = 7, IsConst = true, Value = 8, XCoordinate = 8, YCoordinate = 3},
                new CellDbModel {BlockNumber = 7, IsConst = true, Value = 1, XCoordinate = 8, YCoordinate = 4},
                new CellDbModel {BlockNumber = 7, IsConst = true, Value = 4, XCoordinate = 8, YCoordinate = 5},
                new CellDbModel {BlockNumber = 8, IsConst = true, Value = 5, XCoordinate = 8, YCoordinate = 6},
                new CellDbModel {BlockNumber = 8, IsConst = true, Value = 3, XCoordinate = 8, YCoordinate = 7},
                new CellDbModel {BlockNumber = 8, IsConst = true, Value = 7, XCoordinate = 8, YCoordinate = 8},
            };

            context.TemplateBoards.AddOrUpdate(
                new TemplateBoardDbModel()
                {
                    Id = 1,

                    CellList = cells,

                    EmptyCellsCount = cells.Where(cell => cell.IsConst == false).Count()
                });

            context.Players.AddOrUpdate(
                new PlayerDbModel()
                {
                    Id = 1,

                    Name = "Vasya"
                }
            );
            SeedFromJson(context);
        }

        private void SeedFromJson(SudokuContext context)
        {
            var dataFileName = @"DatabasesInitializeResoureces\Sudoku\SudokuTemplates.json";
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string fullDataFileName = $@"{Path.GetDirectoryName(path)}\{dataFileName}";

            var json = File.ReadAllText(fullDataFileName);
            List<TemplateBoardDbModel> templateDbModels = JsonConvert.DeserializeObject<List<TemplateBoardDbModel>>(json);
            foreach (var board in templateDbModels)
            {
                context.TemplateBoards.AddOrUpdate(board);
            }
        }
    }
}
