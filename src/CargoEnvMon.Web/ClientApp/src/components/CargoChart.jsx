import React, {useEffect, useRef} from "react";
import Chart from "chart.js/auto";

const ID = "cargo-chart";

export function CargoChart({measurements}) {
  const ref = useRef();
  const chartRef = useRef();

  useEffect(() => {
    if (chartRef.current) {
      chartRef.current.destroy();
    }

    chartRef.current = new Chart(ref.current, {
      type: 'line',
      data: {
        labels: measurements.map(e => e.created),
        datasets: [{
          fill: false,
          lineTension: 0,
          backgroundColor: "rgba(0,0,255,1.0)",
          borderColor: "rgba(0,0,255,0.1)",
          data: measurements.map(e => e.temperature),
          label: 'Temperature'
        }],
        options: {
          legend: {display: false},
          scales: {
            yAxes: [{ticks: {min: 6, max: 16}}],
          }
        }
      }
    });
  }, [measurements]);

  return <div style={{maxWidth: '600px'}}>
    <canvas className="cargo-chart" ref={ref} style={{width: '600px'}}/>
  </div>
}