export class ServiceApi {
  static getShipments() {
    return fetch(`/api/mon/shipments`)
      .then(e => e.json());
  }

  static getCargos(shipmentId) {
    return fetch(`/api/mon/shipment/${shipmentId}/cargos`)
      .then(e => e.json());
  }

  static getCargo(cargoId) {
    return fetch(`/api/mon/cargo/${cargoId}`)
      .then(e => e.json());
  }
}