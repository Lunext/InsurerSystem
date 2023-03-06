import { TextField } from "@mui/material"

const NumberField = ({ value, onChange, ...rest}) => {
    return (
        <TextField
            {...rest}
            
            type="numeric"
            value={value}
            onChange={onChange}
            
        />
   
  )
}

export default NumberField;
