import { Component } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { appEmailDomains } from 'src/app/shared/constants';
import { appEmailValidator } from 'src/app/shared/validators';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent {

  showEditMode = false;
  formSubmited = false;

  get user() {
    const {username, email, tel: phoneNumber} = this.authService.user!;
    const [ext, tel] = phoneNumber.split(' ');

    return {
      username,
      email,
      ext,
      tel
    };
  }

  // get addressesArray() {
  //   return (this.form.get('addresses') as FormArray);
  // }

  form = this.fb.group({
    username: ['', [Validators.required, Validators.minLength(5)]],
    email: ['', [Validators.required, appEmailValidator(appEmailDomains)]],
    ext: [''],
    tel: [''],
    // addresses: this.fb.array([
    //   this.fb.group({
    //     postCode: '',
    //     street: ''
    //   })
    // ])
  });

  constructor(private fb: FormBuilder, private authService: AuthService) {
    // this.form.setValue({...this.user, addresses: [{postCode: 'Hello', street: 'World'}]});
    this.form.setValue({...this.user});
  }

  // addNewAddress() {
  //   const newAddress = this.fb.group({
  //     street: '',
  //     postCode: ''
  //   });

  //   this.addressesArray.controls.push(newAddress);
  // }

  toggleEditMode(): void {
    this.showEditMode = !this.showEditMode;

    if (this.showEditMode) {
      this.formSubmited = true;
    }
  }

  saveNewInfo(): void {
    this.formSubmited = false;
    if (this.form.invalid) { return; }

    const {username, email, ext, tel} = this.form.value;
    this.authService.user = {
      username,
      email,
      tel: ext + ' ' + tel
    } as any;

    this.toggleEditMode();
  }
}
