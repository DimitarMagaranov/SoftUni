import './FormInputError.css';

function FormInputError({children}) {

    return children ? <span className="input-error">{children}</span> : null;
}

export default FormInputError;