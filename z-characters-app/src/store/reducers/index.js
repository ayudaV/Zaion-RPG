import Produce from 'immer'
const INITIAL_STATE = {
    user: {
        email: "",
        username: "Any",
        senha: '',
    }
}
export default function login(state = INITIAL_STATE, action) {
    console.log(action)

    switch (action.type) {
        case 'SET_LOGIN': {
            localStorage.setItem('email', action.user.email);
            localStorage.setItem('username', action.user.username);
            localStorage.setItem('senha', action.user.senha);

            return {
                ...state,
                user: action.user,
            };
        }
        default: break;
    }
    return state;
}