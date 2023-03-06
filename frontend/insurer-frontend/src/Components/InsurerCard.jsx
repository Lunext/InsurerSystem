import useInsurer from "../hook/useInsurer";

import { CardActions, CardContent, Typography,Card,Button } from "@mui/material";

const InsurerCard = ({ insurer }) => {
    const { setEdit, deleteInsurer } = useInsurer();
    const { name,id, commission, isApproved } = insurer;
    return (
        <Card
        sx={{ height: '100%',  transition: "0.2s", 
        "&:hover": {
            transform:"scale(1.05)",
        }, }}
            
        >
            <CardContent>
                
                <Typography variant="1rem">
                    Aseguradora: 
                </Typography>
                <Typography component="p" variant="body2 bold">
                    {name}
                </Typography>
                
                <Typography variant="1rem">
                    Comisión: 
                </Typography>
                <Typography component="p" variant="body2">
                    {commission}
                </Typography>

                <Typography variant="1rem">
                    Estado: 
                </Typography>

                {isApproved ? (
                <Typography component="p"
                variant="body2">
                        Activa
                </Typography>
                    
                ) : (
                    <Typography component="p"
                    variant="body2">
                            Inactiva
                    </Typography>
                        
                        
                        
                )}
                

             

                <CardActions>
                    <Button
                        onClick={()=>setEdit(insurer)}
                        variant="container">Editar</Button>
                    <Button color="error"
                    onClick={()=>deleteInsurer(id)}>Remove</Button>
                    
            </CardActions>




            </CardContent>

        </Card>
    )
    
}

export default InsurerCard;