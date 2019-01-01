import config from '../config.js'
import custom from '../libs/custom.js'
const url = config.baseURL


export default {
    payoutTypeQuery() {
        return new Promise((resolve, reject) => {
            $.ajax(custom.initAjaxPost({
                url:url + 'ExpenditureType/QueryPagin',
                data:JSON.stringify({
                    pageNumber:1,
                    amount:999
                }),
                success:function(res){
                    resolve(res)
                }
            }))
        })

    }
}