import config from '../config.js'
import custom from '../libs/custom.js'
import util from './purchase.js'
const url = config.baseURL

const paginationstr = `
<div class="col-lg-9">
<div class="dataTables_paginate paging_bootstrap pagination">
    <ul class="pagination">
        <li class="first disabled"><a href="#">上页</a></li>
        <li class="active"><a href="#">1</a></li>
        <li><a href="#">2</a></li>
        <li><a href="#">3</a></li>
        <li><a href="#">4</a></li>
        <li><a href="#">5</a></li>
        <li class="last"><a href="#">下页</a></li>
    </ul>
</div>
</div>
<div class="col-lg-3">
<div style="margin:10px 15px 18px 0px;float: left;">
    <select name="select" class="form-control">
        <option>1</option>
        <option selected="selected">2</option>
        <option>3</option>
        <option>4</option>
        <option>5</option>
    </select>
</div>
</div>
`





export default class Pagination {
    constructor(totalItems, pageSize = 5, id = '',fn=function(){},currentPage='1') {
        this.totalItems = totalItems
        this.pageSize = pageSize
        this.currentPage = currentPage
        this.id = id
        this.initTable = fn
    }


    getTotalPages() {
        return Math.ceil(this.totalItems / this.pageSize) === 0 ? 1 : Math.ceil(this.totalItems / this.pageSize)
    }
    clear() {
        $(this.el).find('li.item').remove()
        $(this.el).find(`#jump${this.id} option`).remove()
    }
    init() {
        const totalPages = this.getTotalPages()
        if (totalPages < 6) {
            for (let i = 0; i < totalPages; i++) {
                $(`<li class="item "><a href="#">${i+1}</a></li>`).insertBefore($(this.el).find('.last'))
            }
        } else {
            for (let i = 0; i < 5; i++) {
                $(`<li class="item "><a href="#">${i+1}</a></li>`).insertBefore($(this.el).find('.last'))      
            }
        }

        for(let j = 0 ; j < totalPages; j++){
            $(this.el).find(`#jump${this.id}`).append(`<option value="${j+1}">${j+1}</option>`)
        }

        $(this.el).find(`#jump${this.id}`).val(this.currentPage)
 

        this.addActive()
    }


    jump(n) {
        this.clear()
        if (n > 3) {
            n = n - 2
            for (let i = 0; i < 3; i++) {
                $(`<li class="item "><a href="#">${n++}</a></li>`).insertBefore($(`.pagination${this.id} .last`))
            }
            if (n - 1 < this.getTotalPages()) {
                $(`<li class="item "><a href="#">${n}</a></li>`).insertBefore($(`.pagination${this.id} .last`))
                if (n < this.getTotalPages()) {
                    $(`<li class="item "><a href="#">${n+1}</a></li>`).insertBefore($(`.pagination${this.id} .last`))
                }
            }
            this.addActive()
        } else {
            this.init()
        }

        this.initTable({pageNumber:n,amount:this.pageSize})

        // util.initTable({pageNumber:n})

    }

    addActive() {
        let arr = Array.prototype.slice.call($(this.el).find('li.item'))        
        $(arr.find(ele => $(ele).find('a').text() === this.currentPage)).addClass('active').siblings().removeClass('active')
    }


    render() {
        let self = this
        this.el = custom.createDOMFromString(`
        <div class="col-lg-9">
            <div class="dataTables_paginate paging_bootstrap pagination">
                 <ul class="pagination pagination${this.id}">
                     <li class="first"><a href="#">首页</a></li>
                     <li class="last"><a href="#">尾页</a></li>
                </ul>
            </div>
        </div>
        <div class="col-lg-3">
            <div style="margin:10px 15px 18px 0px;float: left;">
                <select name="select" style="height:30px !important" class="form-control" id="jump${this.id}" >
                </select>
            </div>
        </div>`)
        $(this.el).on('click', '.last', function() {
            self.currentPage = self.getTotalPages() + ''
            self.jump(self.currentPage)
        })

        $(this.el).on('click', '.first', function() {
            self.currentPage = '1'
            self.jump(1)
        })


        $(this.el).on('change',`#jump${this.id}`,function(){
            self.currentPage = $(this).val()
            self.jump($(this).val())
        })

        $(this.el).on('click', 'li.item', function() {       
            self.currentPage = $(this).find('a').text()
            self.jump($(this).find('a').text())
        })
        this.init()
        return this.el
    }

}