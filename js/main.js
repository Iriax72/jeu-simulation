// Imports
import {Game} from '../cs/main.cs';

// Références DOM
const canvas = document.querySelector('#game-canvas');
const searchWoodBtn     = document.querySelector('#search-wood-btn');
const createfarmsBtn    = document.querySelector('#farms-btn');
const createCityhallBtn = document.querySelector('#cityhall-btn');

// Fonction utilitaires
function getState() {
    state = {
        wood: Game.Wood,
        meal: Game.Meal,
        farms: Game.Farms,
        hasCityhall: Game.HasCityhall
    }
    return state;
}

function drawScreen() {
    const ctx = canvas.getContext('2d');
    const state = getState();

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

// Initialisation
Game.Init();

// EventListeners
searchWoodBtn.addEventListener('click', () => {
    Game.GetRessources();
    drawScreen();
});

createfarmsBtn.addEventListener('click', () => {
    Game.Createfarms();
    drawScreen();
});

createCityhallBtn.addEventListener('click', () => {
    Game.CreateCityhall();
    drawScreen();
});
