using AutoMapper;
using EntertainmentPortal.DataAccess.Common.Models.Games.Sudoku;
using EntertainmentPortal.Logic.Common.Models.Games.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EntertainmentPortal.Logic.Mappings.Games.Sudoku
{
    public class BoardMappingProfile : Profile
    {
        public BoardMappingProfile()
        {
            TemplateBoardMapping();
            PlayerMapping();
            PlayerBoardMapping();
            CellMapping();    
        }

        private void PlayerMapping()
        {
            CreateMap<PlayerDbModel, Player>()
                .ForMember(player => player.PlayerId, model => model.MapFrom(db => db.Id))
                .ForMember(player => player.Name, model => model.MapFrom(db => db.Name))
                .ForPath(player => player.GamePoints.EasyWinsCount, model => model.MapFrom(db => db.EasyWinsCount))
                .ForPath(player => player.GamePoints.MediumWinsCount, model => model.MapFrom(db => db.MediumWinsCount))
                .ForPath(player => player.GamePoints.HardWinsCount, model => model.MapFrom(db => db.HardWinsCount))
                .ForMember(player => player.LastUnfinishedGame, model => model.MapFrom(db => db.UnfinishedGames.FirstOrDefault()))
                .ReverseMap();
                
            CreateMap<Player, PlayerViewModel>();
        }

        private void TemplateBoardMapping()
        {
            CreateMap<TemplateBoardDbModel, TemplateBoard>()
                .ForMember(board => board.BoardId, model => model.MapFrom(boardDb => boardDb.Id))
                .ForMember(board => board.CellList, model => model.MapFrom(boardDb => boardDb.CellList))
                .ForMember(board => board.DifficultyLevel, model => model.Ignore())
                .ReverseMap();
        }

        private void PlayerBoardMapping()
        {
            CreateMap<PlayerBoardDbModel, PlayerBoard>()
                .ForMember(board => board.BoardId, model => model.MapFrom(boardDb => boardDb.Id))
                .ForMember(board => board.CellList, model => model.MapFrom(boardDb => boardDb.CellList));

            CreateMap<PlayerBoard, PlayerBoardDbModel>()
                .ForMember(boardDb => boardDb.Id, model => model.MapFrom(board => board.BoardId))
                .ForMember(boardDb => boardDb.CellList, model => model.MapFrom(board => board.CellList))
                .ForMember(boardDb => boardDb.Player, model => model.Ignore())
                .ForMember(boardDb => boardDb.TemplateBoard, model => model.Ignore())
                .AfterMap((board, boardDb) =>
                {
                    foreach (var cellDb in boardDb.CellList)
                    {
                        cellDb.PlayerBoardId = boardDb.Id;
                    }
                });

            CreateMap<PlayerBoard, PlayerBoardViewModel>();

            CreateMap<TemplateBoardDbModel, PlayerBoardDbModel>()
                .ForMember(board => board.CellList, model => model.MapFrom(templateBoard => templateBoard.CellList))
                .ForMember(board => board.TemplateBoard, model => model.Ignore())
                .ForMember(board => board.TemplateBoardId, model => model.MapFrom(templateBoard => templateBoard.Id))
                .ForMember(board => board.PlayerId, model => model.Ignore())
                .ForMember(board => board.Player, model => model.Ignore());
        }


        private void CellMapping()
        {
            CreateMap<CellDbModel, Cell>()
                .ForMember(cell => cell.CellId, model => model.MapFrom(cellDb => cellDb.Id))
                .ForMember(cell => cell.BlockNumber, model => model.MapFrom(cellDb => cellDb.BlockNumber))
                .ForMember(cell => cell.IsConst, model => model.MapFrom(cellDb => cellDb.IsConst))
                .ForMember(cell => cell.Value, model => model.MapFrom(cellDb => cellDb.Value))
                .ForMember(cell => cell.XCoordinate, model => model.MapFrom(cellDb => cellDb.XCoordinate))
                .ForMember(cell => cell.YCoordinate, model => model.MapFrom(cellDb => cellDb.YCoordinate));

            CreateMap<Cell, CellDbModel>()
                .ForMember(cellDb => cellDb.BlockNumber, model => model.MapFrom(cell => cell.BlockNumber))
                .ForMember(cellDb => cellDb.IsConst, model => model.MapFrom(cell => cell.IsConst))
                .ForMember(cellDb => cellDb.Value, model => model.MapFrom(cell => cell.Value))
                .ForMember(cellDb => cellDb.XCoordinate, model => model.MapFrom(cell => cell.XCoordinate))
                .ForMember(cellDb => cellDb.YCoordinate, model => model.MapFrom(cell => cell.YCoordinate))
                .ForMember(cellDb => cellDb.Id, model => model.MapFrom(cell => cell.CellId))
                .ForMember(cellDb => cellDb.PlayerBoardId, model => model.Ignore())
                .ForMember(cellDb => cellDb.TemplateBoardId, model => model.Ignore())
                .ForMember(cellDb => cellDb.PlayerBoard, model => model.Ignore())
                .ForMember(cellDb => cellDb.TemplateBoard, model => model.Ignore());

            CreateMap<Cell, CellViewModel>();
        }
    }
}
