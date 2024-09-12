window.canvasConfetti = function () {
    
    var end = Date.now() + (3 * 1000);
    var interval = setInterval(function () {
      
        confetti({
            particleCount: 7,
            angle: 60,
            spread: 55,
            origin: { x: 0 }
        });
        confetti({
            particleCount: 7,
            angle: 120,
            spread: 55,
            origin: { x: 1 }
        });
    }, 250);
};
