// equations taken from http://robertpenner.com/easing/
EasingFunctions = {
    linear: function (t) { return t },

    easeInQuad: function (t) { return t*t },
    easeOutQuad: function (t) { return t*(2-t) },
    easeInOutQuad: function (t) { return t<.5 ? 2*t*t : -1+(4-2*t)*t },

    easeInCubic: function (t) { return t*t*t },
    easeOutCubic: function (t) { return (--t)*t*t+1 },
    easeInOutCubic: function (t) { return t<.5 ? 4*t*t*t : (t-1)*(2*t-2)*(2*t-2)+1 },

    easeInQuart: function (t) { return t*t*t*t },
    easeOutQuart: function (t) { return 1-(--t)*t*t*t },
    easeInOutQuart: function (t) { return t<.5 ? 8*t*t*t*t : 1-8*(--t)*t*t*t },

    easeInQuint: function (t) { return t*t*t*t*t },
    easeOutQuint: function (t) { return 1+(--t)*t*t*t*t },
    easeInOutQuint: function (t) { return t<.5 ? 16*t*t*t*t*t : 1+16*(--t)*t*t*t*t },

    easeInSine: function (t) { return -1.0 * Math.cos(t * Math.PI/2) + 1.0; },
	easeOutSine: function (t) { return Math.sin(t * Math.PI/2); },
    easeInOutSine: function (t) { return -1.0/2 * (Math.cos(Math.PI * t) - 1); },
    
    easeInExpo: function (t) { return (t == 0) ? 0 : Math.pow(2, 10 * (t - 1)); },
	easeOutExpo: function (t) { return (t == 1.0) ? 1.0 : (-Math.pow(2, -10 * t) + 1); },
	easeInOutExpo: function (t) {
		if (t == 0) return 0;
		if (t == 1.0) return 1.0;
        if ((t = t*2) < 1) return 1/2 * Math.pow(2, 10 * (t - 1));
        else return 1/2 * (-Math.pow(2, -10 * --t) + 2);
    },
    
    bounceOut: function(t) {
        if ((t /= 1.0) < 1 / 2.75) {
          return 7.5625 * t * t;
        } else if (t < 2 / 2.75) {
          return 7.5625 * (t -= 1.5 / 2.75) * t + 0.75;
        } else if (t < 2.5 / 2.75) {
          return 7.5625 * (t -= 2.25 / 2.75) * t + 0.9375;
        } else {
          return 7.5625 * (t -= 2.625 / 2.75) * t + 0.984375;
        }
    },
    bounceIn: function(t) {
        return 1.0 - EasingFunctions.bounceOut(1.0 - t);
    },
    bounceInOut: function(t) {
        if (t < 0.5) {
            return EasingFunctions.bounceIn(t * 2) * 0.5;
        } else {
            return EasingFunctions.bounceOut(t * 2 - 1.0) * 0.5 + 0.5;
        }
    }
}

module.exports = EasingFunctions;