import FormInputError from '../shared/FormInputError/FormInputError';

function PetFormView(props) {
    return (
        <section className="create">
            <form onSubmit={props.onSubmitHandler}>
                <fieldset>
                    <legend>{props.onDescriptionChangeHandler ? 'Edit Pet' : 'Add new Pet'}</legend>
                    <p className="field">
                        <label htmlFor="name">Name</label>
                        <span className="input">
                            <input type="text" name="name" id="name" {...(props.data ? {defaultValue: props.data.name} : {placeholder: 'Name'})} />
                            <span className="actions"></span>
                        </span>
                    </p>
                    <p className="field">
                        <label htmlFor="description">Description</label>
                        <span className="input">
                            <textarea onBlur={props.onDescriptionChangeHandler} rows="4" cols="45" type="text" name="description" id="description" {...(props.data ? {defaultValue: props.data.description} : {placeholder: 'Description'})}></textarea>
                            {props.errorMessages.description ? <FormInputError>{props.errorMessages.description}</FormInputError> : null}
                            <span className="actions"></span>
                        </span>
                    </p>
                    <p className="field">
                        <label htmlFor="image">Image</label>
                        <span className="input">
                            <input type="text" name="imageURL" id="image" {...(props.data ? {defaultValue: props.data.imageURL} : {placeholder: 'Image'})} />
                            <span className="actions"></span>
                        </span>
                    </p>
                    <p className="field">
                        <label htmlFor="category">Category</label>
                        <span className="input">
                            <select type="text" name="category">
                                <option value="Cat">Cat</option>
                                <option value="Dog">Dog</option>
                                <option value="Parrot">Parrot</option>
                                <option value="Reptile">Reptile</option>
                                <option value="Other">Other</option>
                            </select>
                            <span className="actions"></span>
                        </span>
                    </p>
                    <input className="button submit" type="submit" value={props.data ? "Edit Pet" : "Add Pet"} />
                </fieldset>
            </form>
        </section>
    );
}

export default PetFormView;