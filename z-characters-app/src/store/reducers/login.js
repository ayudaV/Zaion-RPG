const INITIAL_STATE = {
    user: {
        idJogador: 0,
        username: "",
        senha: "",
        nomeJogador: "",
        urlImagem: "",
        descricao: "",
        role: "",

    }
}
export default function login(state = INITIAL_STATE, action) {
    console.log(action)

    switch (action.type) {
        case 'SET_LOGIN': {
            localStorage.setItem('idJogador', action.user.idJogador);
            localStorage.setItem('username', action.user.username);
            localStorage.setItem('nomeJogador', action.user.nomeJogador);
            localStorage.setItem('urlImagem', action.user.urlImagem);
            localStorage.setItem('descricao', action.user.descricao);
            localStorage.setItem('role', action.user.role);

            return {
                ...state,
                user: action.user,
            };
        }
        default: break;
    }
    return state;
}