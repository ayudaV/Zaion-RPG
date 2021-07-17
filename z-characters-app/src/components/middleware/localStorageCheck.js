import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { setLogin } from "../../store/actions/login";

const LocalStorageCheck = ({ children, setLogin }) => {
    const user = {
        idJogador: localStorage.getItem('idJogador'),
        username: localStorage.getItem('username'),
        nomeJogador: localStorage.getItem('nomeJogador'),
        urlImagem: localStorage.getItem('urlImagem'),
        descricao: localStorage.getItem('descricao'),
        role: localStorage.getItem('role')
    }

    setLogin(user)

    return children;
}

const mapDispatchToProps = dispatch => bindActionCreators({ setLogin }, dispatch)

export default connect(null, mapDispatchToProps)(LocalStorageCheck)