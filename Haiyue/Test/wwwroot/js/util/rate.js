import config from '../config.js'
import custom from '../libs/custom.js'
import game from './game.js'
import currency from './currency.js'
const url = config.baseURL
const newRate =
    `
<div class="panel-body" id="newRate">
  <form class="form-horizontal" id="form-validate"  role="form">
    <div class="form-group">
        <label class="col-lg-2 control-label" for="shortcut">货币缩写</label>
        <div class="col-lg-10">
            <input type="text" class="form-control" id="shortcut">
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-2 control-label" for="sign">货币符号</label>
        <div class="col-lg-10">
            <input type="text" class="form-control" id="sign">
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-2 control-label" for="rateToCNY">与人民币汇率</label>
        <div class="col-lg-10">
            <input type="number" class="form-control" id="rateToCNY" step="0.0001">
        </div>
    </div>
    <div class="form-group">
            <div class="col-lg-offset-2" style="padding-left:15px">
                <button type="submit" id="confirm" class="btn btn-default marginR10">Save changes</button>
                <button type="button" id="cancel" class="btn btn-danger">Cancel</button>
            </div>
    </div>
  </form>
</div>
`


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
                url: url + 'Currency/QueryPagin',
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
                    <td>${ele.name}</td>
                    <td>${ele.symbol}</td>
                    <td>
                        <input type="number" class="tcenter form-control rate" step="0.0001" value="${ele.exchangeRate}">
                    </td>
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

    addNewRate(title) {
        let self = this
        $.jConfirm(title, newRate, '100%', 450)
        $('#cancel').click(function() {
            $.alert._close();
        })

        $('#rateToCNY').on('input propertychange', function() {
            console.log('aaaaaaaaa')
            let self = this
            $(this).val($(self).val().replace(/([\+\-]*)/g, ''))
        })


        $('#confirm').on('click', function(e) {
            e.preventDefault()
            let name = $('#shortcut').val().trim()
            let symbol = $('#sign').val()
            let exchangeRate = $('#rateToCNY').val()

            if (name && symbol && exchangeRate) {
                $.ajax(custom.initAjaxPost({
                    url: url + 'Currency/Create',
                    data: JSON.stringify({
                        name,
                        symbol,
                        exchangeRate,
                    }),
                    success: function(res) {
                        console.log(res)
                        if (res.success) {
                            $.alert._close()
                            $('body').remove('#newRate')
                            self.initTable({
                                pageNumber: $('.pagination li.item.active').find('a').text()
                            })
                        } else {
                            //to do
                            return
                        }
                    }
                }))
            } else {
                alert('请填写完整表单')
            }
        })
    },

    changeRate(dom) {
        $.ajax({
            type: 'GET',
            url: url + `Currency/Edit?id=${dom.attr('data-tr')}&exchangeRate=${dom.find('.rate').val()}`,
            success: function(res) {
                if (res.obj) {
                    alert('修改成功')
                } else {
                    alert('修改失败')
                }

            }
        })
    },
    deleteRate(dom) {
        let self = this


        $.jAlert('警告', '确定要删除这一条吗', '450', '300')

        $('#cancel').click(function() {
            $.alert._close();
        })

        $('#confirm').on('click', function(e) {
            $.ajax({
                type: 'DELETE',
                url: url + `Currency/Delete?id=${dom.attr('data-tr')}`,
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