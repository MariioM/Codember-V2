fun main(){
    val input = "&###@&*&###@@##@##&######@@#####@#@#@#@##@@@@@@@@@@@@@@@*&&@@@@@@@@@####@@@@@@@@@#########&#&##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@##@@&"
    val inputList = input.toCharArray()
    var result = 0
    for(symbol in inputList){
       when(symbol){
            '#' -> result++
            '@' -> result--
            '*' -> result *= result
            '&' -> print(result)
            else -> continue
        }
    }
}