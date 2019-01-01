import config from '../config.js'
import custom from '../libs/custom.js'
const url = config.baseURL



export default {
    currencyQuery(){
        return new Promise((resolve,reject) =>{
            $.ajax({
                type:'GET',
                url:url + 'Currency/QueryAll',
                success:function(res){
                    resolve(res)
                }
            })



            // resolve([{
            //     id:'1',
            //     name:'RMB'
            // }])


        })
    }
}