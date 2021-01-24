// name: exponential timer
// outputs: 1
// initialize: // Code added here will be run once\n// whenever the node is deployed.\n
// finalize: // Code added here will be run when the\n// node is being stopped or re-deployed.\n
// info: 
let timeout = context.get("timer");
let timeoutId = context.get("timeoutId");
clearTimeout(timeoutId);
 
const min = 10;
const max = 100;
 
if(msg.reset) {
    context.set("timer",null);
    node.status({text: 'reset'});
    return;
}
 
if(timeout) {
    timeout = Math.min(Math.round(timeout * 1.5), max);
} else {
    timeout = min;
}
 
timeoutId = setTimeout(() => {
    context.set("timer",null);
    node.status({});
    node.send(msg);
    node.done();
}, timeout * 1000);
 
context.set("timer", timeout);
context.set("timeoutId", timeoutId);
node.status({text: timeout});