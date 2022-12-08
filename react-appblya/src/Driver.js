export async function generateDriver() {
    const response = await fetch('/api/Drivers', {
        method:'GET',
        headers: new Headers({
            'Content-Type':'application/json'
        })
});
let drivernumber = await response.json();
localStorage.setItem("DriverNumber", drivernumber);
return drivernumber;
}