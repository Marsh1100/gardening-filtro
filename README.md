# gardening-filtro
La empresa Gardens especializada en Jardineria desea construir una aplicacion que le permita llevar el control
y registro de todos sus productos y servicios.

# Endpoints
<b>1</b> Devuelve un listado con todos los pagos que se realizaron en el año 2008 mediante Paypal. Ordene el resultado de mayor a menor.
  ```
  http://localhost:5136/api/Payment/paymentsByPaypal2008
  ```
  ```c#
  public async Task<IEnumerable<Payment>> GetPaymentsByPaypal2008()
    {
        return   await _context.Payments
                .Where(d=> d.PaymentMethod == "Paypal" && d.PaymentDate.Year.Equals(2008))
                .OrderByDescending(o=> o.Total)
                .ToListAsync();
    }
  ```
<b>Explicación: </b>Mediante el context se accede a la data de la tabla Payments para luego filtrar con el método .Where que los pagos hayan sido mediante Paypal y en el año correspondiente. Asímismo mediante el método .OrderByDescending se selecciona la columna por la cual se quiere ordenar de mayor a menor.<br><br>
<b>2</b> Devuelve un listado con todas las formas de pago que aparecen en la tabla pago. Tenga en cuenta que no deben aparecer formas de pago repetidas
  ```
  http://localhost:5136/api/Payment/methodsPayments
  ```
  ```

  ```
  <b>Explicación:</b>
<b>3</b> Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
  ```
  http://localhost:5136/api/Client/clientsWithPaymentsAndSeller
  ```
  ```

  ```
  <b>Explicación:</b>
<b>4</b> Devuelve un listado que muestre el nombre de cada empleados, el nombre de su jefe y el nombre del jefe de sus jefe.
  ```
  http://localhost:5136/api/Employee/bossAndSuperBoss
  ```
  ```

  ```
  <b>Explicación:</b>
<b>5</b> y <b>6</b> Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
  ```
  http://localhost:5136/api/Product/withoutRequest
  ```
  ```

  ```
  <b>Explicación:</b>
<b>7</b> ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma descendente por el número de pedidos.
   ```
   http://localhost:5136/api/Request/quantityOfRequestDesc
   ```
  ```

  ```
  <b>Explicación:</b>
<b>8</b> Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
  ```
  http://localhost:5136/api/Client/clientsWithoutPayments
  ```
  ```

  ```
  <b>Explicación:</b>
<b>9</b> Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde está su oficina.
  ```
  http://localhost:5136/api/Client/clientsWithSellerAndOffice
  ```
  ```

  ```
  <b>Explicación:</b>
<b>10</b> Devuelve el nombre del cliente, el nombre y primer apellido de su representante de ventas y el número de teléfono de la oficina del representante de ventas, de aquellos clientes que no hayan realizado ningún pago.
  ```
  http://localhost:5136/api/Client/clientsWithoutPaymentsWithSellerAndOffice
  ```
  ```

  ```
  <b>Explicación:</b>
