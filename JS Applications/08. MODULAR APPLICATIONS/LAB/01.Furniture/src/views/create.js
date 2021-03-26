import { html } from '../../node_modules/lit-html/lit-html.js';
import { createFurniture } from '../api/data.js';

import {notify, clearNotifications} from '../notification.js';

const createTemplate = (onSubmit, isInvalidMake, isInvalidModel, IsInvalidYear, isInvalidDescription, isInvalidPrice, isInvalidImg) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Create New Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class=${'form-control' + (isInvalidMake ? ' is-invalid' : '')} id="new-make" type="text" name="make">
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class=${'form-control' + (isInvalidModel ? ' is-invalid' : '')} id="new-model" type="text" name="model">
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class=${'form-control' + (IsInvalidYear ? ' is-invalid' : '')} id="new-year" type="number" name="year">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class=${'form-control' + (isInvalidDescription ? ' is-invalid' : '')} id="new-description" type="text" name="description">
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class=${'form-control' + (isInvalidPrice ? ' is-invalid' : '')} id="new-price" type="number" name="price">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class=${'form-control' + (isInvalidImg ? ' is-invalid' : '')} id="new-image" type="text" name="img">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class="form-control" id="new-material" type="text" name="material">
            </div>
            <input type="submit" class="btn btn-info" value="Create" />
        </div>
    </div>
</form>`;



export async function createPage(context) {
    context.render(createTemplate(onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);

        const furnitureData = [...formData.entries()].reduce((a, [k, v]) => Object.assign(a, {[k]: v}), {});

        if(Object.entries(furnitureData).filter(([k, v]) => k != 'material').some(([k, v]) => v == '')) {
            context.render(createTemplate(onSubmit, furnitureData.make == '', furnitureData.model == '', furnitureData.year == '', furnitureData.description == '', furnitureData.price == '', furnitureData.img == ''));
            return notify('All fields are required!');
        }

        const data = await createFurniture(furnitureData);

        clearNotifications();
        
        context.page.redirect('/details/' + data._id);
    }
}