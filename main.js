// Références DOM
const canvas = document.querySelector('#game-canvas');
const searchWoodBtn     = document.querySelector('#search-wood-btn');
const createfarmsBtn    = document.querySelector('#farms-btn');
const createCityhallBtn = document.querySelector('#cityhall-btn');

// Fonction utilitaires
async function execCs(functionName) {
    return await DotNet.invokeMethodAsync('jeu-simulation', functionName);
}

async function getState() {
    const state = await execCs('GetState');
    return JSON.parse(await state);
}

async function drawScreen() {
    const ctx = canvas.getContext('2d');
    const state = await getState();

    ctx.clearRect(0, 0, canvas.clientWidth, canvas.clientHeight);
    ctx.font = '20px Arial';

    for (let i = 0; i < state.wood; i++) {
        ctx.fillText('🪵', 60, 25 * i + 3);
    }
    for (let i = 0; i < state.meal; i++) {
        ctx.fillText('🥔', 120, 25 * i + 30);
    }
    for (let i = 0; i < state.farms; i++) {
        ctx.fillText('🏡', 180, 25 * i + 30);
    }
    if (state.hasCityhall) {
        ctx.fillText('🏛️', 240, ctx.clientHeight /2);
    }
}

// EventListeners
searchWoodBtn.addEventListener('click', async () => {
    await execCs('GetRessources');
    await drawScreen();
});

createfarmsBtn.addEventListener('click', async () => {
    await execCs('CreateFarms');
    await drawScreen();
});

createCityhallBtn.addEventListener('click', async () => {
    await execCs('CreateCityhall');
    await drawScreen();
});