using Haiyue.Model;
using Haiyue.Model.Dto;
using Haiyue.Model.Dto.Game;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Haiyue.Service.Services.GameServices
{
    public interface IGameService
    {
        /// <summary>
        /// 添加游戏
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> CreateAsync(GameAddOrEditDto model);

        /// <summary>
        /// 删除游戏
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// 编辑游戏
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnData<bool>> EditAsync(int id, GameAddOrEditDto model);

        /// <summary>
        /// 分页查询游戏
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<ReturnPaginSelectDto<ReturnGameDto>> QueryPaginAsync(SelectGameDto model);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        Task<List<ReturnGameDto>> QueryAll();
    }
}
