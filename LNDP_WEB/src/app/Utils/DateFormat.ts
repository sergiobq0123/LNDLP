export class DateFormat {
  public static format(date: string): string {
    const fecha = new Date(date);
    const dia = fecha.getDate().toString().padStart(2, '0');
    const mes = (fecha.getMonth() + 1).toString().padStart(2, '0');
    const anio = fecha.getFullYear().toString().slice(2);
    return `${dia}/${mes}/${anio}`;
  }
}
