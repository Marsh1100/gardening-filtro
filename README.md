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
  ```c#
  public async Task<IEnumerable<object>> GetMethodsPayments()
    {
        return   await _context.Payments
                .GroupBy(a=>a.PaymentMethod)
                .Select(b=> b.Key ).ToListAsync();
    }
  ```
  <b>Explicación:</b> Mediante el context se accede a la data de la tabla Payments, luego se agrupa con el método .GroupBy la columna PayMethod para que se agrupen sin que se repitan y luego mediante un select seleccionamos la llave de la anterior agrupación, que contiene los diferentes metodos de pago posibles.
  <br><br>

<b>3</b> Devuelve el nombre de los clientes que han hecho pagos y el nombre de sus representantes junto con la ciudad de la oficina a la que pertenece el representante.
  ```
  http://localhost:5136/api/Client/clientsWithPaymentsAndSeller
  ```
  ```c#
  public async Task<IEnumerable<object>> GetClientsWithPaymentsAndSeller()
    {
        return await (from client in _context.Clients
                        join payment in _context.Payments on client.Id equals payment.IdClient
                        join employee in _context.Employees on client.IdEmployee equals employee.Id
                        join office in _context.Offices on employee.IdOffice equals office.Id   
                        select new {
                            name_client = client.NameClient,
                            employee = new {
                                    name = employee.Name + employee.FirstSurname,
                                    city_of_office = office.City
                            }
                        }
                    )
                    .Distinct()
                    .ToListAsync();
    }
  ```
  <b>Explicación:</b> Para esta consulta se debe hacer uso de 4 tablas diferentes, por ello utilizamos un join que permita tener toda la información requerida mediante los Id que se compartan entre las tablas, para luego seleccionar los valores que se solicitan.
  <br><br>
  
<b>4</b> Devuelve un listado que muestre el nombre de cada empleados, el nombre de su jefe y el nombre del jefe de sus jefe.
  ```
  http://localhost:5136/api/Employee/bossAndSuperBoss
  ```
  ```

  ```
  <b>Explicación:</b>
  <br><br>
<b>5</b> y <b>6</b> Devuelve un listado de los productos que nunca han aparecido en un pedido. El resultado debe mostrar el nombre, la descripción y la imagen del producto.
  ```
  http://localhost:5136/api/Product/withoutRequest
  ```
  ```c#
  public async Task<IEnumerable<object>> GetWithoutRequest()
    {

        var products = await _context.Products.ToListAsync();
        var producttypes  = await _context.Producttypes.ToListAsync();
        var requestdetails = await _context.Requestdetails.ToListAsync();

       return (from product in  products
                join requestdetail in requestdetails on product.Id equals requestdetail.IdProduct into h
                join producttype in producttypes on product.IdProductType equals producttype.Id
                from all in h.DefaultIfEmpty()
                where all?.Id == null
                select new {
                    product_name = product.Name,
                    description = product.Description,
                    image = producttype.Image
                }).Distinct();
                            
    }
  ```
  <b>Explicación:</b> Para esta consulta se debe hacer uso de tres tablas diferentes. Como la consulta solicita que se requiere obtener los productos que no se encuentren en un pedido se utiliza join y a su vez into, que permite acceder al el conjunto de la tabla requestdetail para despues mediante la funcion .DefaultIfEmpty muestre un registro así este no contenga información. Luego con el condicional Where nos aseguramos que solo sean los pedidos que se encuentran vacios (es decir, tiene el IdCliente pero este no tiene registro) y selecciona los valores que se solicitan.
  <br><br>
<b>7</b> ¿Cuántos pedidos hay en cada estado? Ordena el resultado de forma descendente por el número de pedidos.
   ```
   http://localhost:5136/api/Request/quantityOfRequestDesc
   ```
  ```c#
  public async  Task<IEnumerable<object>> GetQuantityOfRequestDesc()
    {
        return await _context.Requests
                        .GroupBy(a=> a.State)
                        .Select(s=> new {
                            state = s.Key,
                            quantity = s.Count()
                        })
                        .OrderByDescending(o=> o.quantity)
                        .ToListAsync();
    }
  ```
  <b>Explicación:</b> En esta consulta mediante el context accedemos a la tabla requests donde hacemos una agrupación según el estado en que se encuentre el pedido. Para después seleccionar los datos mostrar su key y con el método .Count va a mostrar el total de registros que hay por ese state. Al final mediante el método .OrderByDescending se ordenan de forma descendiente dicha cantidad contada.
  <br><br>
<b>8</b> Devuelve un listado que muestre solamente los clientes que no han realizado ningún pago.
  ```
  http://localhost:5136/api/Client/clientsWithoutPayments
  ```
  ```c#
  public async Task<IEnumerable<Client>> GetClientsWithoutPayments()
    {
        var clients = await _context.Clients.ToListAsync();
        return  (from client in clients
                        join payment in _context.Payments on client.Id equals payment.IdClient into h
                        from all in h.DefaultIfEmpty()
                        where all?.Id == null
                        select client
                ).Distinct();
    }
  ```
  <b>Explicación:</b> Se utilizan las tablas clients y payments para determinar cuales son esos clientes que no se encuentran en la tabla payments. Para eso se usa un join y a su vez un into para contener ese conjunto de payments para luego mediante el metodo .DefaultIFEmpty permitir mostrar todos los registros así estos se encuentren vacíos. Luego con el condicional where nos aseguramos que el registro en una columna especifica (en este caso Id de payment) sea nulo para así seleccionar a los clientes.
  <br><br>
<b>9</b> Devuelve el listado de clientes donde aparezca el nombre del cliente, el nombre y primer apellido de su representante de ventas y la ciudad donde está su oficina.
  ```
  http://localhost:5136/api/Client/clientsWithSellerAndOffice
  ```
  ```

  ```
  <b>Explicación:</b>
  <br><br>
<b>10</b> Devuelve el nombre del cliente, el nombre y primer apellido de su representante de ventas y el número de teléfono de la oficina del representante de ventas, de aquellos clientes que no hayan realizado ningún pago.
  ```
  http://localhost:5136/api/Client/clientsWithoutPaymentsWithSellerAndOffice
  ```
  ```

  ```
  <b>Explicación:</b>
  <br><br>
