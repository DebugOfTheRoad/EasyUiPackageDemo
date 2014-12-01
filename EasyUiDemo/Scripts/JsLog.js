//日志开关 若为1 则输出console日志
var log_switch = 1;
function log(msg, value) {
    if (log_switch == 1) {
        console.info(msg + value);
    }
}