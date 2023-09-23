import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactWebComponent } from './contact-web.component';

describe('ContactWebComponent', () => {
  let component: ContactWebComponent;
  let fixture: ComponentFixture<ContactWebComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ContactWebComponent]
    });
    fixture = TestBed.createComponent(ContactWebComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
