import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenericYoutubeComponent } from './generic-youtube.component';

describe('GenericYoutubeComponent', () => {
  let component: GenericYoutubeComponent;
  let fixture: ComponentFixture<GenericYoutubeComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GenericYoutubeComponent]
    });
    fixture = TestBed.createComponent(GenericYoutubeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
