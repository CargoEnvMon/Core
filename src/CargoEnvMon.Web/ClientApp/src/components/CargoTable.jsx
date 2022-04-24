import React from "react";
import {Table} from "reactstrap";

export function CargoTable({measurements}) {
  return <Table bordered style={{width: '400px', marginTop: '15px'}}>
    <thead>
    <tr>
      <th>Measured at</th>
      <th>Temperature</th>
    </tr>
    </thead>
    <tbody>
    {measurements.map(({created, temperature}) => {
      return <tr key={created}>
        <td>
          {created}
        </td>
        <td>
          {temperature}
        </td>
      </tr>
    })}
    </tbody>
  </Table>
}