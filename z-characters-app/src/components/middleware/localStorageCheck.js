import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { setLogin } from "../../store/actions/login";

const LocalStorageCheck = ({ children, setLogin }) => {
    const user = {
        idUsuario: localStorage.getItem('idUsuario'),
        username: localStorage.getItem('username'),
        email: localStorage.getItem('email'),
        descricao: localStorage.getItem('descricao'),

    }

    setLogin(user)

    return children;
}

const mapDispatchToProps = dispatch => bindActionCreators({ setLogin }, dispatch)

export default connect(null, mapDispatchToProps)(LocalStorageCheck)