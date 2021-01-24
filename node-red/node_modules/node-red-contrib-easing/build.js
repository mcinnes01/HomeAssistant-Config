const plt = require('matplotnode');
const _ = require('lodash');
const EasingFunctions = require("./easing-functions");

// function to create chart from function
function plotFunction(func, title, filename) {
    const x = _.range(0, 1.0, 1.0/100);
    plt.title(title);
    plt.xlim(-0.1,1.1);
    plt.ylim(-0.1,1.1);
    plt.plot(x, x.map(func), 'color=r');
    plt.xlabel("t")
    plt.ylabel("f(t)")
    plt.save(filename);
    plt.close();
}

// generate charts
_.forEach(EasingFunctions, (func, key) => {
    plotFunction(func, key, "assets/functions/" + key + ".png")
    console.log("generated chart for: " + key);
});


