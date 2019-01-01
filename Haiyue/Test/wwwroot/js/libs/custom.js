export default {
    initAjaxPost(obj){
        return Object.assign({},{
            type:"POST",
            contentType:'application/json'
        },obj)
    },
    accMul(arg1, arg2) {
        var m = 0,
            s1 = arg1.toString(),
            s2 = arg2.toString();
        try {
            m += s1.split(".")[1].length
        } catch (e) {}

        try {
            m += s2.split(".")[1].length
        } catch (e) {}
        return Number(s1.replace(".", "")) * Number(s2.replace(".", "")) / Math.pow(10, m)

    },
    createDOMFromString(str){
        var div = document.createElement('div')
        div.innerHTML = str
        return div
    },
}