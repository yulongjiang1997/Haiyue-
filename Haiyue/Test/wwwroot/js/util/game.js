import config from '../config.js'
import custom from '../libs/custom.js'
const url = config.baseURL


export default {
    gameQuery() {
        return new Promise((resolve, reject) => {
            $.ajax({
                type: 'GET',
                url: url + 'Game/Query',
                success: function(res) {
                    resolve(res)
                }
            })
        })

    }
}