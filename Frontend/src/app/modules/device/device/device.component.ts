import { Component, ElementRef, ViewChild } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DeviceService } from '../../../shared/services/device.service';
import {
  FormGroup,
  FormBuilder,
  Validators,
  FormControl,
  FormArray,
} from '@angular/forms';
import { Device } from '../../../shared/models/device.model';

@Component({
  selector: 'app-device',
  templateUrl: './device.component.html',
  styleUrl: './device.component.css',
})
export class DeviceComponent {
  @ViewChild('input')
  input!: ElementRef<HTMLInputElement>;

  id: number = 0;
  Title: string = 'Device : New Device';
  options: string[] = ['Unknown', 'Laptop', 'Mobile', 'DeskPhone', 'HeadPhones', 'Other'];
  filteredOptions: string[];

  deviceForm = this.formBuilder.group<DeivceFormModel>({
    id: this.formBuilder.control({ value: 0, disabled: true }),
    name: this.formBuilder.control(''),
    type: this.formBuilder.control(''),
    barcode: this.formBuilder.control(''),
    shared: this.formBuilder.control(false),
    description: this.formBuilder.control(''),
  });

  constructor(
    private route: ActivatedRoute,
    private service: DeviceService,
    private formBuilder: FormBuilder
  ) {
    this.filteredOptions = this.options.slice();
    this.id = parseInt(this.route.snapshot.paramMap.get('id') as string);
    if (this.id > 0) this.SetTitle();
  }

  filter(): void {
    const filterValue = this.input.nativeElement.value.toLowerCase();
    this.filteredOptions = this.options.filter(o => o.toLowerCase().includes(filterValue));
  }

  SetTitle() {
    this.GetDevice();
  }

  GetDevice() {
    this.service.Get(this.id).subscribe((data) => {
      this.deviceForm.patchValue(data);
      this.Title = `${this.deviceForm.controls.name.value} - ${this.deviceForm.controls.barcode.value}`;
    });
  }

  submit() {
    let device = <Device>this.deviceForm.value;
    device.id = this.id;
    if(device.id > 0)
      this.service.Update(device).subscribe((data) => console.log(data));
    else
      this.service.Create(device).subscribe((data) => console.log(data));
    }
}

interface DeivceFormModel {
  id: FormControl<number | null>;
  name: FormControl<string | null>;
  type: FormControl<string | null>;
  barcode: FormControl<string | null>;
  shared: FormControl<boolean | null>;
  description: FormControl<string | null>;
}
