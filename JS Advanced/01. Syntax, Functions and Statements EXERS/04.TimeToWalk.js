function solve(stepsCount, footMeter, speedKmH) {
    const speed = (speedKmH * 1000) / 3600;
    const distance = stepsCount * footMeter;
    const restsInSeconds = Math.floor(distance / 500) * 60;
    let totalSeconds = (distance / speed) + restsInSeconds;

    const hours = (Math.floor(totalSeconds / 3600)).toFixed(0).padStart(2, "0");
    totalSeconds %= 3600;
    const minutes = (Math.floor(totalSeconds / 60)).toFixed(0).padStart(2, "0");
    const seconds = (totalSeconds % 60).toFixed(0).padStart(2, "0");

    return `${hours}:${minutes}:${seconds}`;
}

console.log(solve(4000, 0.60, 5));