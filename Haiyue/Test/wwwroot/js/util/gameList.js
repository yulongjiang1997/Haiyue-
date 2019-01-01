import config from '../config.js'
import custom from '../libs/custom.js'
import game from './game.js'
import currency from './currency.js'
const url = config.baseURL



export default {
    initTable({
        pageNumber = 1,
        amount = 10,
    } = {
        pageNumber: 1,
        amount: 10,
    }) {
        return new Promise((resolve, reject) => {
            $.ajax({
                type: 'POST',
                url: url + 'Game/QueryPagin',
                contentType: 'application/json',
                data: JSON.stringify({
                    pageNumber,
                    amount,
                }),
                success: function(res) {
                    let tbody = $('tbody')
                    tbody.empty()
                    res.items.forEach((ele, index) => {
                        const str =
                            `         
                <tr data-tr="${ele.id}">
                    <td>${ele.id}</td>
                    <td class="name" data-td="${ele.name}">${ele.name}</td>
                    <td>
                        <div class="controls center">
                            <a href="#" title="Remove user" class="tip remove"><span class="icon12 icomoon-icon-remove"></span></a>
                        </div>
                    </td>
                </tr>               
                 `
                        tbody.append(str)
                    })
                    resolve(res)
                }
            })

        })

    },

    addNewGame(name) {
        let self = this
        if(!name){
            alert('请填写正确的游戏名称')
            return
        }
        $.ajax(custom.initAjaxPost({
            url:url + 'Game/Create',
            data:JSON.stringify({
                name
            }),
            success:function(res){
                if(res.obj){
                    self.initTable({
                        pageNumber:$('.pagination li.item.active').find('a').text()
                    }) 
                }
            }
        }))

    },

    deleteRate(dom) {
        let self = this


        $.jAlert('警告', `确定要删除${dom.find('.name').attr('data-td')}吗`, '450', '300')

        $('#cancel').click(function() {
            $.alert._close();
        })

        $('#confirm').on('click', function(e) {
            $.ajax({
                type: 'DELETE',
                url: url + `Game/Delete?id=${dom.attr('data-tr')}`,
                success: function(res) {
                    if (res.obj) {
                        $.alert._close()
                        self.initTable({
                            pageNumber:$('.pagination li.item.active').find('a').text()
                        })
                    } else {
                        alert('删除失败')
                    }
                }
            })
        })
    }

}