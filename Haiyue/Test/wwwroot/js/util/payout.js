import config from '../config.js'
import custom from '../libs/custom.js'
import game from './game.js'
import currency from './currency.js'
const url = config.baseURL
const newPayout = `
<div class="panel-body">


<form class="form-horizontal" id="form-validate" action="./basic.html" method="POST" role="form">
    <div class="form-group">
        <label class="col-lg-2 control-label" for="datepicker">支出日期</label>
        <div class="col-lg-10">
            <input class="form-control" id="datepicker" name="date" type="text" />
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-2 control-label" for="requireds">支出类别</label>
        <div class="col-lg-10">
            <input type="text" class="form-control" id="requireds" name="sort">
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-2 control-label" for="requiredm">金额</label>
        <div class="col-lg-10">
            <input type="text" class="form-control" id="requiredm" name="money">
        </div>
    </div>
    <div class="form-group">
        <label class="col-lg-2 control-label" for="required">备注(可选)</label>
        <div class="col-lg-10">
            <textarea class="form-control" id="url" name="plus" type="text"></textarea>
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
        amount = 5,
        beginTime=$('#startDatepicker').val(),
        endTime=$('#endDatepicker').val(),
        selectCondition = $('#optionSelect').val(),
        selectKeyword = '*',
        expenditureTypeId = $('#payoutType').val(),
        type='init',
        initPagi = false
    } = {
        pageNumber: 1,
        amount: 5,
        beginTime:$('#startDatepicker').val(),
        endTime:$('#endDatepicker').val(),
        selectCondition:$('#optionSelect').val(),
        selectKeyword:'*',
        expenditureTypeId : $('#payoutType').val()
    }) {
        return new Promise((resolve, reject) => {
            $.ajax({
                type: 'POST',
                url: url + 'Expenditure/QueryPagin',
                contentType: 'application/json',
                data: JSON.stringify({
                    pageNumber,
                    amount,
                    beginTime,
                    endTime ,
                    selectCondition,
                    selectKeyword,
                    expenditureTypeId
                }),
                success: function(res) {
                    console.log(res)
                //     let tbody = $('tbody')
                //     tbody.empty()
                //     res.obj.items.forEach((ele, index) => {
                //     const str = `<tr data-td="${ele.id}">
                //     <td data-td="${date}" class="date">${date}</td>
                //     <td data-td="${ele.orderNumber}" class="orderNumber">${ele.orderNumber}</td>
                //     <td data-td="${ele.serverName}" class="serverName">${ele.serverName}</td>
                //     <td data-td="${ele.number}" class="number">${ele.number}</td>
                //     <td data-td="${ele.totalNumber}" class="totalNumber">${ele.totalNumber}</td>
                //     <td data-td="${ele.unitPrice}" class="unitPrice">${ele.unitPrice}</td>
                //     <td data-td="${ele.totalPrice}" class="totalPrice">${ele.totalPrice}</td>
                //     <td data-td="${ele.realIncome}" data-plus="${ele.currencyName}" class="realIncome">${ele.realIncome}</td>
                //     <td data-td="${ele.realIncomeRMB}" class="realIncomeRMB">${ele.realIncomeRMB}</td>
                //     <td data-td="${ele.paymentAccount}" class="paymentAccount">${ele.paymentAccount}</td>
                //     <td data-td="${ele.paymentStatus}" class="paymentStatus">${parseInt(ele.paymentStatus) ? `<select name="" id="" class="changePaymentStatus tcenter"><option value="1" selected>未支付</option><option value="1">已支付</option></select>` : "已支付"} </td>
                //     <td class="more cPointer remarks" data-td="${ele.remarks}"></td>
                //     <td data-td="${ele.supplierPhone}" class="supplierPhone">${ele.supplierPhone}</td>
                //     <td data-td="${ele.handler}" class="handler">${ele.handler}</td>
                //     <td>
                //         <div class="controls center">
                //             <a href="#" title="edit user" class="tip edit"><span class="icon12 icomoon-icon-pencil"></span></a>
                //         </div>
                //     </td>
                // </tr>`
                //         tbody.append(str)
                //     })
                //     resolve(res)
                }
            })

        })

    },

    dynamicAdd() {
        return Promise.all([game.gameQuery(), currency.currencyQuery()]).then(res => {
            let gameList = res[0]
            let currencyList = res[1].obj
            gameList.forEach(ele => {
                $('#gamename').append(`<option value="${ele.id}">${ele.name}</option>`)
            })
            currencyList.forEach(ele => {
                $('#sort').append(`<option value="${ele.id}">${ele.name}</option>`)
            })
            return true
        }, err => {
            alert('网络错误，请稍后重试')
        })
    },

    addNewPurchase(title, add = true, id) {

        let self = this

        $.jConfirm(title, newPurchase, '100%', 450)

        $('#cancel').click(function() {
            $.alert._close();
        })
        $("#newPurchase #datepicker").datepicker({
            showOtherMonths: true
        });


        $('#num').on('input propertychange', function() {
            let self = this
            $(this).val($(self).val().replace(/[^\d\.]/g, ''))
            if ($('#per').val()) {
                $('#amount').val(custom.accMul($(self).val(), $('#per').val()))
            }
        })
        $('#per').on('input propertychange', function() {
            let self = this
            $(this).val($(self).val().replace(/([\+\-]*)/g, ''))
            if ($('#num').val()) {
                $('#amount').val(custom.accMul($(self).val(), $('#num').val()))
            }
        })

        this.dynamicAdd().then(res => {

        })

        $('#confirm').on('click', function(e) {
            e.preventDefault()
            let gameId = $('#gamename').val()
            let datepicker = $('#datepicker').val()
            let orderId = $('#orderId').val().trim()
            let server = $('#server').val().trim()
            let num = $('#num').val().trim()
            let total = $('#total').val().trim()
            let per = $('#per').val().trim()
            let amount = $('#amount').val()
            let sort = $("#sort").val()
            let get = $('#get').val().trim()
            let contact = $('#contact').val().trim()
            let payaccount = $('#payaccount').val().trim()
            let paystate = $('#paystate').val()
            let plus = $('#plus').val()
            if (gameId && datepicker && orderId && server && num && total && per && amount && sort && get && contact && payaccount && paystate) {

                $.ajax(custom.initAjaxPost({
                    url: add ? url + 'Purchase/Create' : url + `Purchase/Edit?id=${id}`,
                    data: JSON.stringify({
                        gameId: gameId,
                        handlerId: localStorage.getItem('user') || 'admin',
                        orderDate: datepicker,
                        orderNumber: orderId,
                        serverName: server,
                        number: num,
                        totalNumber: total,
                        unitPrice: per,
                        totalPrice: amount,
                        currencyId: sort,
                        realIncome: get,
                        supplierPhone: contact,
                        paymentAccount: payaccount,
                        paymentStatus: paystate,
                        remarks: plus
                    }),
                    success: function(res) {
                        if (res.success) {
                            $.alert._close()
                            $('body').remove('#newPurchase')
                            self.initTable({
                                pageNumber:$('.pagination li.item.active').find('a').text()
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
    modifyPurchase(dom) {
        this.addNewPurchase('修改', false, dom.attr('data-td'))
        Promise.all([game.gameQuery(), currency.currencyQuery()]).then(res => {
            let gameList = res[0]
            let currencyList = res[1].obj
            let gameValue = gameList.find(ele => ele.name === dom.find('.gameName').attr('data-td')).id
            let currency = currencyList.find(ele => ele.name === dom.find('.realIncome').attr('data-plus')).id
            $('#gamename').val(gameValue)
            $('#sort').val(currency)
            $('#datepicker').val(dom.find('.date').attr('data-td'))
            $('#orderId').val(dom.find('.orderNumber').attr('data-td'))
            $('#server').val(dom.find('.serverName').attr('data-td'))
            $('#num').val(dom.find('.number').attr('data-td'))
            $('#total').val(dom.find('.totalNumber').attr('data-td'))
            $('#per').val(dom.find('.unitPrice').attr('data-td'))
            $('#amount').val(dom.find('.totalPrice').attr('data-td'))
            $('#get').val(dom.find('.realIncome').attr('data-td'))
            $('#payaccount').val(dom.find('.paymentAccount').attr('data-td'))
            $('#paystate').val(dom.find('.paymentStatus').attr('data-td'))
            $('#plus').val(dom.find('.remarks').attr('data-td'))
            $('#contact').val(dom.find('.supplierPhone').attr('data-td'))
        })
    },
    changePaymentStatus(dom) {
        $.ajax({
            type: 'GET',
            url: url + `Purchase/EditPaymentStatus?id=${dom.attr('data-td')}`,
            success: function(res) {
                console.log(res)
                dom.find('.paymentStatus').attr('data-td', '0')
                dom.find('.paymentStatus').html('已支付')
            }
        })
    },
    // pagiInitTable(n,a){
    //     var start = $('#startDatepicker').val()
    //     var end = $('#endDatepicker').val()
    //     var game = $('#gameSelect').val()
    //     var option = $('#optionSelect').val()
    //     var text = $('#searchContent').val()
    //     var status = $('#paymentStatusSelect').val()
  
    //     this.initTable({
    //         pageNumber:n,
    //         amount:a,
    //         beginTime:start,
    //         endTime:end,
    //         gameId:game,
    //         paymentStatus:status,
    //         selectCondition:option,
    //         selectKeyword:text
    //     })
    // }
}